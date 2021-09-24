using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tcc_backend.DataBaseConfig;
using Tcc_backend.Entities;

namespace Tcc_backend.Dao {
    public class RelacaoUserStoriesDao {

        DatabaseContext _databaseContext = new DatabaseContext();

        public int AddOrUpdateRelacao(int userStoryFilhoID, int userStoryPaiID) {

            var relacao = _databaseContext.RelacaoUserStories.FirstOrDefault(x => x.HistoriaUsuarioFilhoID == userStoryFilhoID);

            if (relacao != null && relacao != default) {

                relacao.HistoriaUsuarioPaiID = userStoryPaiID;

                _databaseContext.Update(relacao);
                _databaseContext.SaveChanges();
                return relacao.RelacaoUserStoryID;

            } else {

                RelacaoUserStory novaRelacao = new RelacaoUserStory() {
                    HistoriaUsuarioPaiID = userStoryPaiID,
                    HistoriaUsuarioFilhoID = userStoryFilhoID,
                };

                _databaseContext.RelacaoUserStories.Add(novaRelacao);
                _databaseContext.SaveChanges();
                return novaRelacao.RelacaoUserStoryID;
            }


        }
    }
}
