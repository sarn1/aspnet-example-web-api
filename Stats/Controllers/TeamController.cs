using Stats.DataAccess;
using Stats.Filters;
using Stats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stats.Controllers
{
    public class TeamController : BaseApiController
    {
        public TeamController() : base(new StatsService())
        {

        }

        public IHttpActionResult Get()
        {
            try
            {
                var teams = StatsService.Teams.Get();
                var models = teams.Select(ModelFactory.Create);

                return Ok(models);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var team = StatsService.Teams.Get(id);
                var model = ModelFactory.Create(team);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody] TeamModel teamModel)
        {
            try
            {
                var teamEntity = ModelFactory.Create(teamModel);
                var team = StatsService.Teams.Insert(teamEntity);

                var model = ModelFactory.Create(team);
                return Created(string.Format("http://localhost:50408/api/team/{0}", model.TeamId), model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ModelValidator]
        public IHttpActionResult Put([FromBody] TeamModel teamModel)
        {
            try
            {
                var teamEntity = ModelFactory.Create(teamModel);
                var team = StatsService.Teams.Update(teamEntity);

                var model = ModelFactory.Create(team);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var teamEntity = StatsService.Teams.Get(id);
                if (teamEntity != null)
                    StatsService.Teams.Delete(teamEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}