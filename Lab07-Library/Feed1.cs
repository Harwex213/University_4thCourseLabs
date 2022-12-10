using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using WebServices_Lab06Model;

namespace Lab07_Library
{
    public static class DataSource
    {
        public static WebServices_Lab06Entities Client = new WebServices_Lab06Entities(new Uri("http://localhost:9001/WSKOA.svc/"));
    }

    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Feed1" в коде и файле конфигурации.
    public class Feed1 : IFeed1
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            SyndicationFeed feed = new SyndicationFeed("Оценки студентов", "Лента оценок студентов", null);
            List<SyndicationItem> items = new List<SyndicationItem>();
            feed.Items = items;

            var students = DataSource.Client.Students.ToList();
            foreach (var student in students)
            {
                var notes = DataSource.Client.Notes.Where(n => n.studentId == student.id).ToList();
                var formattedNotes = notes.GroupBy(n => n.subj)
                    .Select(g => $"Предмет {g.Key}: " + string.Join(", ", g.Select(n => n.note)))
                    .ToList();
                items.Add(new SyndicationItem(student.name, string.Join(";\n", formattedNotes), null));
            }
            
            // Возвращать канал ATOM или RSS, основываясь на строке запроса
            // RSS-&gt; http://localhost:8733/Design_Time_Addresses/Lab07_Library/Feed1/
            // Atom-&gt; http://localhost:8733/Design_Time_Addresses/Lab07_Library/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }
    }
}
