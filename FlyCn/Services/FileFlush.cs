﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace FlyCn.Services
{
    public class FileFlush
    {
        public static void FileFlushing()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(FileDeleteThread);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FileDeleteComplete);
            worker.RunWorkerAsync(HttpContext.Current);

          //  HttpContext.Current.Application.GetVariables().FileFlushing = worker;
            HttpContext.Current.Application["FileFlushing"] = worker;
        }
        private static void FileDeleteThread(object sender, DoWorkEventArgs e)
        {
            //Get current HttpContext from the DoWorkEventArgs object
            HttpContext.Current = (HttpContext)e.Argument;

            while (true)
            {
                var minutes = 30;
                System.Threading.Thread.Sleep(minutes * 60 * 1000);
                try
                {
                   // Array.ForEach(Directory.GetFiles(HttpContext.Current.Server.MapPath("~/tempImages/")), File.Delete);
                    //------------------Deleting temporary image files created by webservices called from mobile app--------
                    string[] filePaths = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/tempImages/"));
                    foreach (string filePath in filePaths)
                        if (DateTime.UtcNow - File.GetCreationTimeUtc(filePath) > TimeSpan.FromMinutes(5))
                        {
                            File.Delete(filePath);
                        }
                    //------------------Deleting temporary files created by excel files----------------
                    string[] filePaths2 = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Content/Fileupload/"));
                    foreach (string filePath in filePaths2)
                        if (DateTime.UtcNow - File.GetCreationTimeUtc(filePath) > TimeSpan.FromHours(10))
                        {
                            File.Delete(filePath);
                        }

                }
                catch (Exception ex)
                {
                }
            }
        }
        private static void FileDeleteComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Do nothing
        }
        public static void StopFileDeleteThread()
        {
            BackgroundWorker worker = (BackgroundWorker)HttpContext.Current.Application["FileFlushing"];
            if (worker != null)
                worker.CancelAsync();
        }
    }
}