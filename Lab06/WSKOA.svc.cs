//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using Lab06.Models;
using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Data.Services.Providers;
using System.ServiceModel.Web;

namespace Lab06
{
    public class WSKOA : EntityFrameworkDataService<WebServices_Lab06Entities>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet]
        public string InsertStudent(string name)
        {
            try
            {
                var student = new Student
                {
                    name = name
                };
                var context = CurrentDataSource;
                context.Students.Add(student);
                context.SaveChanges();
                return "Successfully created";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }

        [WebGet]
        public string UpdateStudent(long id, string name)
        {
            try
            {
                var context = CurrentDataSource;
                var student = context.Students.Find(id);
                if (student == null)
                {
                    throw new DataServiceException("Not found");
                }
                student.name = name;
                context.SaveChanges();
                return "Successfully updated";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }

        [WebGet]
        public string DeleteStudent(long id)
        {

            try
            {
                var context = CurrentDataSource;
                var student = context.Students.Find(id);
                if (student == null)
                {
                    throw new DataServiceException("Not found");
                }
                var notes = new Note[student.Note.Count];
                student.Note.CopyTo(notes, 0);
                foreach (var note in notes)
                {
                    context.Notes.Remove(note);
                }
                context.Students.Remove(student);
                context.SaveChanges();
                return "Successfully deleted";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }

        [WebGet]
        public string InsertNote(long studentId, string subj, int note)
        {
            try
            {
                var noteRecord = new Note
                {
                    studentId = studentId,
                    subj = subj,
                    note = note,
                };
                var context = CurrentDataSource;
                context.Notes.Add(noteRecord);
                context.SaveChanges();
                return "Successfully created";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }

        [WebGet]
        public string UpdateNote(long id, long studentId, string subj, int note)
        {
            try
            {
                var context = CurrentDataSource;
                var noteRecord = context.Notes.Find(id);
                if (noteRecord == null)
                {
                    throw new DataServiceException("Not found");
                }
                noteRecord.studentId = studentId;
                noteRecord.subj = subj;
                noteRecord.note = note;
                context.SaveChanges();
                return "Successfully updated";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }

        [WebGet]
        public string DeleteNote(long id)
        {
            try
            {
                var context = CurrentDataSource;
                var noteRecord = context.Notes.Find(id);
                if (noteRecord == null)
                {
                    throw new DataServiceException("Not found");
                }
                context.Notes.Remove(noteRecord);
                context.SaveChanges();
                return "Successfully deleted";
            }
            catch (Exception e)
            {
                throw new DataServiceException(e.Message + "\n" + (e.InnerException?.InnerException?.Message ?? ""));
            }
        }
    }
}
