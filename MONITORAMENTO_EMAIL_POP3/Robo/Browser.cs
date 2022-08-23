using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MONITORAMENTO_EMAIL_POP3.Robo
{
    class Browser
    {
        public IWebDriver Driver { get; set; }

        public Browser()
        {
            string caminho_chromedriver = "";
            try
            {
                caminho_chromedriver = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                caminho_chromedriver = caminho_chromedriver.Replace("chromedriver.exe", "");
            }
            catch (Exception)
            {
                caminho_chromedriver = @"C:\tools\chromedriver\";
            }

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-default-browser-check", "--disable-infobars", "no-sandbox", "--start-maximized", "--ignore-certificate-errors", "--disable-popup-blocking", "--app=");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            //options.AddArguments("--incognito");
            var chromeDriverDevice = ChromeDriverService.CreateDefaultService();
            chromeDriverDevice.HideCommandPromptWindow = true;
            //options.AddArguments("user-data-dir=c:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\");
            chromeDriverDevice.LogPath = caminho_chromedriver + "chromedriver.log";
            chromeDriverDevice.EnableVerboseLogging = true;
            Driver = new ChromeDriver(chromeDriverDevice, options, TimeSpan.FromMinutes(3));

        }

        public void GoToUrl(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Não foi possível acessar a URL {url}");
            }
        }

        public IWebElement SourceElement(string attribute, string nameElement, bool exception = true)
        {
            try
            {
                switch (attribute.ToUpper())
                {
                    case "CLASS":
                        return Driver.FindElement(By.ClassName(nameElement));
                    case "CLASS2":
                        nameElement = "//*[@class='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "ID":
                        nameElement = "//*[@id='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "NAME":
                        nameElement = "//*[@name='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "TAGNAME":
                        return Driver.FindElement(By.TagName(nameElement));
                    case "XPATH":
                        return Driver.FindElement(By.XPath(nameElement));
                    case "TITLE":
                        nameElement = "//*[@title='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "ARIAL":
                        nameElement = "//*[@aria-label='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "VALUE":
                        nameElement = "//*[@value='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "CSS":
                        return Driver.FindElement(By.CssSelector(nameElement));
                    case "ROLE":
                        nameElement = "//*[@role='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "TEXT":
                        nameElement = "//*[contains(text(),'" + nameElement + "')]";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "PLACEHOLDER":
                        nameElement = "//*[@placeholder='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "DARB":
                        nameElement = "//*[@data-aura-rendered-by='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    case "DPI":
                        nameElement = "//*[@data-proxy-id='" + nameElement + "']";
                        return Driver.FindElement(By.XPath(nameElement));
                    default:
                        throw new InvalidOperationException($"Atributo {attribute} inválido");
                }
            }
            catch (Exception)
            {
                if (exception)
                    throw new InvalidOperationException($"Não foi possível localizar o atributo: " + attribute + " - nome: " + nameElement);
                else
                    return null;
            }
        }

        public IReadOnlyList<IWebElement> SrcElements(string attribute, string nameElement)
        {
            try
            {
                switch (attribute.ToUpper())
                {
                    case "CLASS":
                        return Driver.FindElements(By.ClassName(nameElement));
                    case "ID":
                        return Driver.FindElements(By.Id(nameElement));
                    case "NAME":
                        return Driver.FindElements(By.Name(nameElement));
                    case "TAGNAME":
                        return Driver.FindElements(By.TagName(nameElement));
                    case "XPATH":
                        return Driver.FindElements(By.XPath(nameElement));
                    case "TITLE":
                        nameElement = "//*[@title='" + nameElement + "']";
                        return Driver.FindElements(By.XPath(nameElement));
                    case "ROLE":
                        nameElement = "//*[@role='" + nameElement + "']";
                        return Driver.FindElements(By.XPath(nameElement));
                    case "TEXT":
                        nameElement = "//*[contains(text(),'" + nameElement + "')]";
                        return Driver.FindElements(By.XPath(nameElement));
                    default:
                        throw new InvalidOperationException($"Atributo {attribute} inválido");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Click(string attribute, string nameElement)
        {
            try
            {
                SourceElement(attribute, nameElement).Click();
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Não foi possivel clicar no elemento: atributo: {attribute} - nome do elemento: {nameElement}");
            }
        }

        public void MoveToIframe(string attribute, string nameElement)
        {
            try
            {
                Driver.SwitchTo().Frame(SourceElement(attribute, nameElement));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message + $" | Erro em MoveToIframe({attribute},{nameElement})");
            }
        }
        public void MoveToIframeDefault()
        {
            try
            {
                Driver.SwitchTo().DefaultContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void TryClick(string attribute, string nameElement, int attemps, int TimeInterval)
        {
            try
            {
                IWebElement element;
                int count = 0;
                do
                {
                    Wait(TimeInterval);
                    element = SourceElement(attribute, nameElement, false);
                    count++;
                } while (element == null && count <= attemps);

                if (element != null)
                {
                    element.Click();
                }
                else
                {
                    throw new InvalidOperationException($"Não foi possivel encontrar no elemento: atributo: {attribute}-nome do elemento: {nameElement}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Atributo: {0} - Nome: {1} - Message: {2}", attribute, nameElement, ex.Message));
            }
        }

        public void Write(string attribute, string nameElement, string text)
        {
            try
            {
                var element = SourceElement(attribute, nameElement);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message + $" | Erro em Write({attribute}, {nameElement})");
            }
        }

        public void TryWrite(string attribute, string nameElement, string text, int attemps = 3, int TimeInterval = 3)
        {
            try
            {
                IWebElement element = null;
                int count = 0;
                do
                {
                    element = SourceElement(attribute, nameElement, false);
                    if (element == null)
                        Wait(TimeInterval);
                    count++;
                } while (element == null && count < attemps);

                if (element != null)
                {
                    element.Clear();
                    element.SendKeys(text);
                }
                else
                {
                    throw new InvalidOperationException($"Não foi possivel encontrar no elemento: atributo: {attribute}-nome do elemento: {nameElement}");
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message + $" | Erro em Write({attribute}, {nameElement})");
            }
        }


        public string GetText(string attribute, string nameElement, bool exception = true)
        {
            try
            {
                return SourceElement(attribute, nameElement).Text;
            }
            catch (Exception ex)
            {
                if (exception)
                {
                    throw new InvalidOperationException(ex.Message + $" | Erro em GetText({attribute},{nameElement})");
                }
                else
                {
                    return null;
                }
            }
        }
        public string GetTextInput(string attribute, string nameElement, bool exception = true)
        {
            try
            {
                return SourceElement(attribute, nameElement).GetAttribute("value");
            }
            catch (Exception ex)
            {
                if (exception)
                {
                    throw new InvalidOperationException(ex.Message + $" | Erro em GetText({attribute},{nameElement})");
                }
                else
                {
                    return null;
                }
            }
        }


        public string[] GetTextOfAllElements(string attribute, string nameElement)
        {
            try
            {
                var elements = SrcElements(attribute, nameElement);

                //String[] textOfElements = new String[elements.Count];
                List<string> textOfElements = new List<string>();

                foreach (var item in elements)
                {
                    textOfElements.Add(item.Text);
                }

                return textOfElements.ToArray();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message + $" | Erro em GetText({attribute},{nameElement})");
            }
        }

        public bool WaitLoadElement(string attribute, string nameElemento, int attemps, int TimeInterval, bool throwEx = true)
        {
            try
            {
                IWebElement element;
                int count = 0;
                do
                {
                    Wait(TimeInterval);
                    element = SourceElement(attribute, nameElemento, false);
                    count++;
                } while (element == null && count <= attemps);

                if (element == null && throwEx == true)
                {
                    throw new InvalidOperationException($"Não foi possivel encontrar no elemento: atributo: {attribute}-nome do elemento: {nameElemento}");
                }
                else if (element == null && throwEx == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerifyElementExists(string attribute, string nameElemento, int attemps, int TimeInterval, bool throwEx = true)
        {
            try
            {
                IWebElement element;
                int count = 0;
                do
                {
                    Wait(TimeInterval);
                    element = SourceElement(attribute, nameElemento, false);
                    count++;
                } while (element == null && count <= attemps);

                if (element == null && throwEx == true)
                {
                    throw new InvalidOperationException($"Não foi possivel encontrar no elemento: atributo: {attribute}-nome do elemento: {nameElemento}");
                }
                else if (element == null && throwEx == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool WaitLoadPage(string TittlePage, int attemps, int TimeInterval, bool throwEx = true)
        {
            try
            {
                bool pageLoaded;
                int count = 0;
                do
                {
                    Wait(TimeInterval);
                    pageLoaded = Driver.Title.Contains(TittlePage);
                    count++;
                } while (pageLoaded == false && count <= attemps);

                if (pageLoaded == false && throwEx == true)
                {
                    throw new InvalidOperationException($"A pagina com titulo {TittlePage} não foi carregada");
                }
                else if (pageLoaded == false && throwEx == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetTitle()
        {
            try
            {
                return Driver.Title;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AttempsGetElement(string xPath, string cssSelector, string className, string id, string text, string nomeElemento, bool exception)
        {
            string texto = null;
            try
            {
                if (xPath != null)
                {
                    texto = GetText("XPATH", xPath, false);
                }
                if (cssSelector != null && texto == null)
                {
                    texto = GetText("CSS", cssSelector, false);
                }
                if (className != null && texto == null)
                {
                    texto = GetText("CLASS", className, false);
                }
                if (id != null && texto == null)
                {
                    texto = GetText("ID", id, false);
                }
                if (text != null && texto == null)
                {
                    texto = GetText("TEXT", text, true);
                }

            }
            catch (Exception)
            {
                if (exception)
                {
                    throw new InvalidOperationException($"Não foi possível localizar o elemento {nomeElemento} na tela.");
                }
                else
                {
                    return null;
                }
            }
            if (texto == "")
            {
                return null;
            }
            else
            {
                return texto;
            }
        }

        public bool AttempsSourceElement(string xPath, string text, string id, string name, string css, string nomeElemento, bool exp = true)
        {
            IWebElement element = null;
            try
            {
                if (xPath != null)
                {
                    element = SourceElement("XPATH", xPath, false);
                }
                if (text != null && element == null)
                {
                    element = SourceElement("TEXT", text, false);
                }
                if (id != null && element == null)
                {
                    element = SourceElement("ID", id, false);
                }
                if (name != null && element == null)
                {
                    element = SourceElement("NAME", name, true);
                }
                if (css != null && element == null)
                {
                    element = SourceElement("CSS", css, true);
                }
                return element == null ? false : true;
            }
            catch (Exception)
            {
                if (exp)
                {
                    throw new InvalidOperationException($"Não foi possível localizar o elemento {nomeElemento} na tela.");
                }
                else
                {
                    return false;
                }
            }
        }
        public void AttempsClickElement(string xPath, string text, string css, string arial, string id, string nomeElemento, bool exp = true)
        {
            IWebElement element = null;
            try
            {
                if (xPath != null)
                {
                    element = SourceElement("XPATH", xPath, false);
                }
                if (text != null && element == null)
                {
                    element = SourceElement("TEXT", text, false);
                }
                if (css != null && element == null)
                {
                    element = SourceElement("CSS", css, false);
                }
                if (arial != null && element == null)
                {
                    element = SourceElement("ARIAL", arial, true);
                }
                if (id != null && element == null)
                {
                    element = SourceElement("ID", id, true);
                }
                if (element != null)
                {
                    element.Click();
                }
                else
                {
                    throw new InvalidOperationException($"Não foi possível localizar o elemento {nomeElemento} na tela.");
                }
            }
            catch (Exception)
            {
                if (exp)
                {
                    throw new InvalidOperationException($"Não foi possível localizar o elemento {nomeElemento} na tela.");
                }
                else
                {

                }

            }
        }

        public void ExecuteJScript(string scripts)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(scripts);
        }
        public void Quit()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Wait(int timeSleep)
        {
            Thread.Sleep(timeSleep * 1000);
        }
        public void WaitLocateElement(int Interval)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Interval);
        }
        public void ClickOkAlert(int TimeInterval)
        {
            try
            {
                IAlert alert = null;
                do
                {
                    alert = Driver.SwitchTo().Alert();
                    alert.Accept();
                    Wait(TimeInterval);
                }
                while (alert != null);
            }
            catch (Exception)
            {

            }
        }

        public string GetMessageAlert(int TimeInterval, bool exp = true)
        {
            string texto = null;
            try
            {
                texto = Driver.SwitchTo().Alert().Text;
                Driver.SwitchTo().Alert().Accept();
                Wait(TimeInterval);
                return texto;
            }
            catch (Exception)
            {
                if (exp)
                {
                    throw new InvalidOperationException($"Alert Google Chrome avisa:  {texto}.");
                }
                return null;
            }

        }

        public void InputAlternative(string attribute, string nameElement, string text)
        {
            try
            {
                IWebElement element = SourceElement(attribute, nameElement);
                string teste = element.GetAttribute("data-aura-rendered-by");
                IList<IWebElement> input = element.FindElements(By.TagName("label"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteAllCookiesChrome()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
        }
        public void CloseBrowser()
        {
            if (Driver != null)
                Driver.Close();
        }
        public void PressEnter(string attribute, string nameElement)
        {
            try
            {
                IWebElement element = SourceElement(attribute, nameElement);
                element.SendKeys(Keys.Return);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SelectClientProfile(string clientName)
        {
            try
            {
                IWebElement divClient = SourceElement("CLASS", "scopesListSection");
                IList<IWebElement> lblName = divClient.FindElements(By.TagName("li"));
                //clicando na aba Clientes no menu lateral esquerdo
                foreach (IWebElement li in lblName)
                {
                    if (li.Text.ToUpper().Trim().Contains("CLIENTES"))
                    {
                        li.FindElement(By.TagName("a")).Click();
                        break;
                    }
                }
                Wait(5);
                //clicando no nome do cliente apresentado na tabela
                IReadOnlyList<IWebElement> linkName = SrcElements("TITLE", clientName);
                foreach (IWebElement link in linkName)
                {
                    if (link.TagName.Equals("a"))
                    {
                        link.Click();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ClickTableContato()
        {
            try
            {
                IWebElement table = SourceElement("CLASS", "uiVirtualDataGrid--default");
                IList<IWebElement> itens = table.FindElements(By.TagName("tr"));
                IList<IWebElement> linhas = itens[1].FindElements(By.TagName("td"));
                linhas[0].FindElement(By.TagName("a")).Click();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void OpenLastAtendimento()
        {
            try
            {
                IWebElement table = SourceElement("ARIAL", "Atendimentos").FindElement(By.TagName("tbody"));
                IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
                IWebElement firstRow = rows[0].FindElement(By.TagName("th"));
                firstRow.FindElement(By.TagName("a")).Click();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SelectTabAtendimentos()
        {
            try
            {
                IWebElement ul = SourceElement("CLASS2", "slds-card__body slds-card__body--inner").FindElement(By.TagName("ul"));
                IList<IWebElement> lis = ul.FindElements(By.TagName("li"));
                foreach (IWebElement li in lis)
                {
                    if (li.Text.ToUpper().Contains("ATENDIMENTO"))
                    {
                        li.Click();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ClickCriarDemanda()
        {
            try
            {
                IReadOnlyList<IWebElement> btns = SrcElements("TAGNAME", "button");
                foreach (IWebElement btn in btns)
                {
                    if (btn.Text.Equals("Criar Demanda"))
                    {
                        btn.Click();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CloseTabs()
        {
            try
            {
                IWebElement divTab = SourceElement("ARIAL", "Guias do espaço de trabalho para Console de serviço");
                IWebElement linha = divTab.FindElement(By.ClassName("tabBarItems"));
                IList<IWebElement> tabs = linha.FindElements(By.ClassName("oneConsoleTabItem"));
                foreach (IWebElement btnClose in tabs)
                {
                    //Buscando e clicando no segundo botão da aba (X)
                    var btns = btnClose.FindElements(By.ClassName("slds-button_icon-x-small"));
                    btns[1].Click();
                    Wait(2);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
