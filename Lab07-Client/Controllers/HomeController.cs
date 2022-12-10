using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Lab07_Client.Controllers
{
    public class Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            using (XmlReader reader = XmlReader.Create("http://localhost:10000/SyndicationService/CreateFeed"))
            {
                var formatter = new Rss20FeedFormatter();
                formatter.ReadFrom(reader);
                var feed = formatter;
                ViewBag.Title = feed.Feed.Title.Text;
                ViewBag.Decsription = feed.Feed.Description.Text;
                var items = feed.Feed.Items.Select(i => new Item
                {
                    Title = i.Title.Text,
                    Description = ((TextSyndicationContent)i.Content).Text
                });
                return View(items);
            }

            //var feedClient = new SyndicationService.Feed1Client();
            //var feed = feedClient.CreateFeed();

        }
    }
}