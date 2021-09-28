using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tcc_backend.Dao;
using Tcc_backend.Entities;
using Tcc_backend.Models;

namespace Tcc_backend.Business {
    public class CommitBusiness {

        CommitDao _dao = new CommitDao();
        UserStoryDao _userStoryDao = new UserStoryDao();
        ProjetoDao _projetoDao = new ProjetoDao();

        public Commit Get(int CommitID) {
            return _dao.Get(CommitID);
        }

        public List<Commit> ListByUserStoryID(int UserStoryID) {
            return _dao.ListByUserStoryID(UserStoryID);
        }

        public int Adicionar(CommitModelCreate model) {

            var commit = new Commit() {
                Author = model.Author,
                Message = model.Message,
                UserStoryID = model.UserStoryID,
            };

            return _dao.Adicionar(commit);
        }

        public void Delete(int CommitID) {

            Commit commit = new Commit() {
                CommitID = CommitID,
            };

            _dao.Delete(commit);
        }

        public CommitModel EntityToModel(Commit commit) {

            CommitModel model = new CommitModel() {
                CommitID = commit.CommitID,
                Author = commit.Author,
                Message = commit.Message,
                UserStoryID = commit.UserStoryID,
            };

            return model;
        }

        public void PullCommitsFromGithub() {

            var lastCheck = _dao.GetLastCheckDate();

            if (lastCheck.AddDays(1) < DateTime.Now) {

                string retorno = "";

                var commitListFromDatabase = _dao.ListAllShasIDs();

                try {

                    var projetos = _projetoDao.ListAll();

                    foreach (var projeto in projetos) {

                        retorno = PullCommitsByUrl(projeto.UrlGit);

                        List<CommitsObject> listaObjetosCommits = JsonConvert.DeserializeObject<List<CommitsObject>>(retorno);

                        var userStories = _userStoryDao.ListByProjeto(projeto.ProjetoID);

                        foreach (var commitObj in listaObjetosCommits) {

                            foreach (var userStory in userStories) {

                                if (commitObj.commit.message.Contains($"#{userStory.UserStoryID}")) {

                                    if (!commitListFromDatabase.Contains(commitObj.sha)) {

                                        Commit commitEntity = new Commit() {
                                            Message = commitObj.commit.message,
                                            Url = commitObj.html_url,
                                            Author = commitObj.commit.author.name,
                                            UserStoryID = userStory.UserStoryID,
                                            Sha = commitObj.sha,
                                        };

                                        _dao.Adicionar(commitEntity);

                                    }
                                }

                            }
                        }
                    }

                    _dao.UpdateCheckDate(DateTime.Now);

                }
                catch (Exception ex) {
                    throw new Exception(ex.Message);
                }
            }

        }

        public string PullCommitsByUrl(string url) {

            HttpClient httpClient = new HttpClient();
            var byteArray = new UTF8Encoding().GetBytes("5bfb664aa84c83d5f708:ccda6fc6204cee61995540b6a5c32efb0ecf4bdc");

            string toBeSearched = "https://github.com/";

            int index = url.IndexOf(toBeSearched);

            string repoUrl = url.Substring(index + toBeSearched.Length);

            var splitText = repoUrl.Split('/', 2);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{splitText[0]}/{splitText[1]}/commits");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.cloak-preview");

            var name = new ProductInfoHeaderValue("felimenta970", "1.0");

            httpRequestMessage.Headers.UserAgent.Add(name);

            HttpResponseMessage response = httpClient.SendAsync(httpRequestMessage).Result;

            string responseString = response.Content.ReadAsStringAsync().Result;

            return responseString;
        }
    }
}
