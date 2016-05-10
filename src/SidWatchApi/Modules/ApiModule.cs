using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy;
using SidWatch.Api.ResponseObjects;
using Sidwatch.Library.Managers;
using Sidwatch.Library.Objects;
using SidWatchApi.Extensions;
using SidWatchApi.Helpers;
using SidWatchApi.ResponseObjects;
using TreeGecko.Library.AWS.Helpers;
using TreeGecko.Library.Common.Helpers;

namespace SidWatchApi.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get["/api/authorize"] = _parameters => Response.AsError(HttpStatusCode.MethodNotAllowed, null);

            Post["/api/authorize"] = _parameters =>
            {
                BaseResponse br = Authorize(_parameters);
                return Response.AsSuccess(br);
            };

            Get["/api/stations"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites/{siteid}/spectrum/latest"] = _parameters =>
            {
                return null;
            };

            Get["/api/sites/{siteid}/spectrum/{start}/{end}"] = _parameters =>
            {
                return null;
            };

            Post["/api/sites/{siteid}/files/{fileName}"] = _parameters =>
            {
                BaseResponse br = HandleFilePost(_parameters);
                return Response.AsSuccess(br);
            };
        }

        private BaseResponse Authorize(
            DynamicDictionary _parameters)
        {
            User user;
            BaseResponse response = AuthHelper.Authorize(Request, out user);
            return response;
        }

        private BaseResponse HandleGetSites()
        {
            var response = new GetSitesResponse { Success = false };
            User user;

            if (AuthHelper.IsAuthorized(Request, out user))
            {
                SidWatchManager manager = new SidWatchManager();

                List<Site> sites = manager.GetActiveSites();
                
                response.Sites = sites.To


            }

            return response;
        }

        private BaseResponse HandleGetStations()
        {
            var response = new BaseResponse { Success = false };
            User user;

            if (AuthHelper.IsAuthorized(Request, out user))
            {
                SidWatchManager manager = new SidWatchManager();

                List<Station> stations = manager.GetActiveStations();


            }

            return response;
        }

        private BaseResponse HandleFilePost(DynamicDictionary _parameters)
        {
            var response = new BaseResponse { Success = false };
            User user;

            if (AuthHelper.IsAuthorized(Request, out user))
            {
                SidWatchManager manager = new SidWatchManager();

                byte[] fileData = null;
                string fileName = null;

                if (Request.Files.Any())
                {
                    HttpFile file = Request.Files.First();

                    long length = file.Value.Length;
                    fileData = new byte[(int)length];
                    file.Value.Read(fileData, 0, (int)length);
                    fileName = file.Name;
                }

                if (fileName != null)
                {
                    string fileNoExtension = Path.GetFileNameWithoutExtension(fileName);

                    DateTime dateTime;

                    if (DateTime.TryParse(fileNoExtension, out dateTime))
                    {

                        try
                        {
                            string bucketName = Config.GetSettingValue("UploadBucket");

                            //Store to s3
                            string tempSiteId = _parameters["siteid"];

                            Guid siteId;

                            if (Guid.TryParse(tempSiteId, out siteId))
                            {
                                string s3Filename = string.Format("/{0}/{1}/{2}/{3}/{4}",
                                    siteId,
                                    dateTime.Year,
                                    dateTime.Month,
                                    dateTime.Day,
                                    fileName);

                                //Save the file to s3
                                S3Helper.PersistFile(bucketName, s3Filename, "binary/octet-stream", fileData);

                                //Store record of file record in db
                                DataFile dataFile = new DataFile
                                {
                                    Active = true,
                                    Archived = false,
                                    Available = true,
                                    Processed = false,
                                    Filename = s3Filename,
                                    ParentGuid = siteId
                                };
                                manager.Persist(dataFile);
                                
                                //Update SiteDay record
                                

                                response.Success = true;
                                return response;
                            }


                        }
                        catch (Exception ex)
                        {
                            manager.LogException(user.Guid, ex);
                        }
                    }
                    else
                    {
                        response.Error = "Filename is not in date format";
                        response.Message = "Send correct date format";
                    }

                }
            }
            else
            {
                response.Error = "Unauthorized";
                response.Message = "Reauthenticate";
            }

            return response;
        }
    }
}