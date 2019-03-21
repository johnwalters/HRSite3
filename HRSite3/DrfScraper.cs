using HRSite3;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRSite
{
    public class DrfScraper
    {
        // https://www.drf.com/live_odds/winodds/track/GG/USA/11/D

        public void TestBing()
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            //browser.UseDefaultCookiesParser = false;

            WebPage homePage = browser.NavigateToPage(new Uri("http://www.bing.com/"));

            PageWebForm form = homePage.FindFormById("sb_form");
            form["q"] = "scrapysharp";
            form.Method = HttpVerb.Get;
            WebPage resultsPage = form.Submit();

            HtmlNode[] resultsLinks = resultsPage.Html.CssSelect("div.sb_tlst h3 a").ToArray();

            WebPage blogPage = resultsPage.FindLinks(By.Text("romcyber blog | Just another WordPress site")).Single().Click();
        }


        public void TestLiveOddsScrapySharp()
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            //browser.UseDefaultCookiesParser = false;

            WebPage racePage = browser.NavigateToPage(new Uri("http://www.equibase.com/static/entry/FG032019USA1-EQB.html"));



            var tableRowElements = racePage.Html.CssSelect("table > tbody > tr");

           
        }

        public void TestEquibaseScrapySharp()
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            //browser.UseDefaultCookiesParser = false;

            WebPage racePage = browser.NavigateToPage(new Uri("http://www.equibase.com/static/entry/FG032019USA1-EQB.html"));



            var tableRowElements = racePage.Html.CssSelect("table").ToArray();


        }

        public void TestEquibaseHAP()
        {
            // From Web
            var url = "http://www.equibase.com/static/entry/FG032019USA1-EQB.html";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var a = doc;
        }

        public void TestLiveOddsSimpleBrowser()
        {

            var browser = new Browser();
            try
            {
                // log the browser request/response data to files so we can interrogate them in case of an issue with our scraping
                browser.RequestLogged += OnBrowserRequestLogged;
                browser.MessageLogged += new Action<Browser, string>(OnBrowserMessageLogged);

                // we'll fake the user agent for websites that alter their content for unrecognised browsers
                browser.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.224 Safari/534.10";

                // browse to GitHub
                browser.Navigate("https://www.drf.com/live_odds");
                if (LastRequestFailed(browser)) return; // always check the last request in case the page failed to load
                browser.Log(browser.CurrentHtml, LogMessageType.Internal); 
                // click the login link and click it
                browser.Log("First we need to log in, so browse to the login page, fill in the login details and submit the form.");
                var raceLink = browser.Find("a", FindBy.Text, "Louisiana Downs");
                if (!raceLink.Exists)
                    browser.Log("Can't find the login link! Perhaps the site is down for maintenance?");
                else
                {
                    raceLink.Click();
                    if (LastRequestFailed(browser)) return;

                    // fill in the form and click the login button - the fields are easy to locate because they have ID attributes
                    browser.Find("login_field").Value = "youremail@domain.com";
                    browser.Find("password").Value = "yourpassword";
                    browser.Find(ElementType.Button, "name", "commit").Click();
                    if (LastRequestFailed(browser)) return;

                    // see if the login succeeded - ContainsText() is very forgiving, so don't worry about whitespace, casing, html tags separating the text, etc.
                    if (browser.ContainsText("Incorrect login or password"))
                    {
                        browser.Log("Login failed!", LogMessageType.Error);
                    }
                    else
                    {
                        // After logging in, we should check that the page contains elements that we recognise
                        if (!browser.ContainsText("Your Repositories"))
                            browser.Log("There wasn't the usual login failure message, but the text we normally expect isn't present on the page");
                        else
                        {
                            browser.Log("Your News Feed:");
                            // we can use simple jquery selectors, though advanced selectors are yet to be implemented
                            foreach (var item in browser.Select("div.news .title"))
                                browser.Log("* " + item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                browser.Log(ex.Message, LogMessageType.Error);
                browser.Log(ex.StackTrace, LogMessageType.StackTrace);
            }
            finally
            {
                var path = WriteFile("log-" + DateTime.UtcNow.Ticks + ".html", browser.RenderHtmlLogFile("SimpleBrowser Sample - Request Log"));
                
            }

        }

        static bool LastRequestFailed(Browser browser)
        {
            if (browser.LastWebException != null)
            {
                browser.Log("There was an error loading the page: " + browser.LastWebException.Message);
                return true;
            }
            return false;
        }

        static void OnBrowserMessageLogged(Browser browser, string log)
        {
            Console.WriteLine(log);
        }

        static void OnBrowserRequestLogged(Browser req, HttpRequestLog log)
        {
            Console.WriteLine(" -> " + log.Method + " request to " + log.Url);
            Console.WriteLine(" <- Response status code: " + log.ResponseCode);
        }

        static string WriteFile(string filename, string text)
        {
            var dir = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"));
            if (!dir.Exists) dir.Create();
            var path = Path.Combine(dir.FullName, filename);
            File.WriteAllText(path, text);
            return path;
        }
    }
}
