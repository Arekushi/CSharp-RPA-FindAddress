using BuscaCEP.Model;
using BuscaCEP.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace BuscaCEP.Selenium
{
    public class Finder
    {
        private readonly IWebDriver webDriver;
        private readonly String URL_ADDRESS;
        private ChromeOptions chromeOptions;
        private ChromeDriverService service;

        #region [Public Methods]

        public Finder()
        {
            ConfigOptions();
            ConfigService();

            URL_ADDRESS = Resources.ResourceManager.GetString(nameof(URL_ADDRESS));

            webDriver = new ChromeDriver(service, chromeOptions)
            {
                Url = URL_ADDRESS,
            };
        }

        public void Reset()
        {
            webDriver.Url = URL_ADDRESS;
        }

        public Address FindAddressByCEP(string cep)
        {
            webDriver.FindElement(By.Id(nameof(cep))).SendKeys(cep);
            webDriver.FindElement(By.Id("btn_pesquisar")).Click();

            return GetAddressInfo();
        }

        #endregion

        #region [Private Methods]

        private void ConfigOptions()
        {
            chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>()
            {
                "--silent-launch", "--no-startup-window", "no-sandbox", "headless"
            });
        }

        private void ConfigService()
        {
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
        }

        private Address GetAddressInfo()
        {
            var result = webDriver.FindElements(By.TagName("td"), 10);

            return new Address(result);
        }

        #endregion
    }
}
