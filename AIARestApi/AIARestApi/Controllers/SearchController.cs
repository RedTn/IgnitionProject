using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace AIARestApi
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private AIADbEntities db = new AIADbEntities();

        public void AddSearchCriteria()
        {
            throw new System.NotImplementedException();
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ById/{query}")]
        [HttpGet]
        public IHttpActionResult ById(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            if (quotes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ByIdSearch(query, quotes).ToList());
            }
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByFirstName/{query}")]
        [HttpGet]
        public IHttpActionResult ByFirstName(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(ByFirstNameSearch(query, quotes).ToList());
        }

        private IQueryable<Quote> ByFirstNameSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.CustomerFirstName.ToString().StartsWith(query));
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByLastName/{query}")]
        [HttpGet]
        public IHttpActionResult ByLastName(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(ByLastNameSearch(query, quotes).ToList());
        }

        private IQueryable<Quote> ByLastNameSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.CustomerLastName.ToString().StartsWith(query));
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByState/{query}")]
        [HttpGet]
        public IHttpActionResult ByState(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(ByStateSearch(query, quotes).ToList());
        }

        private IQueryable<Quote> ByStateSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.State.ToString().StartsWith(query));
        }
        [ResponseType(typeof(List<Quote>))]
        [Route("ByPhone/{query}")]
        [HttpGet]
        public IHttpActionResult ByPhone(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(ByPhoneSearch(query, quotes).ToList());
        }

        private IQueryable<Quote> ByPhoneSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.CustomerPhone.ToString().StartsWith(query));
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByAddress/{query}")]
        [HttpGet]
        public IHttpActionResult ByAddress(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(ByAddressSearch(query, quotes).ToList());
        }

        private IQueryable<Quote> ByAddressSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.CustomerAddress.ToString().StartsWith(query));
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByDateRange")]
        [HttpGet]
        public IHttpActionResult ByDateRange(string start, string end)
        {
            IQueryable<Quote> quotes = db.Quotes;
            if (quotes == null)
            {
                return NotFound();
            }
            else return Ok(ByDateSearch(start,end,quotes));
        }

        private IQueryable<Quote> ByDateSearch(string start, string end, IQueryable<Quote> quotes)
        {
            var startTime = DateTime.Parse(start);
            var endTime = DateTime.Parse(end);
            return quotes.Where(x => (x.SubmissionTime > startTime && x.SubmissionTime < endTime));
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("ByAddress/{query}")]
        [HttpGet]
        public IHttpActionResult BySubmitted(string query)
        {
            IQueryable<Quote> quotes = db.Quotes;
            
            if (quotes == null)
            {
                return NotFound();
            }

            return Ok(BySubmittedSearch(Boolean.Parse(query), quotes).ToList());
        }

        [ResponseType(typeof(List<Quote>))]
        [Route("Multiple")]
        [HttpGet]
        public IHttpActionResult Multiple(string Id = "", string FirstName = "", string LastName = "",
            string DateStart = "", string DateEnd = "", string zip = "", string state = "", string submitted = "", string phone = "")
        {
            IQueryable<Quote> quotes = db.Quotes;

            if (quotes == null)
            {
                return NotFound();
            }
            IQueryable<Quote> temp;

            if (Id != String.Empty && Id != null)
            {
                temp = ByIdSearch(Id, quotes);
                quotes = temp;
            }
            if (FirstName != String.Empty && FirstName != null)
            {
                temp = ByFirstNameSearch(FirstName, quotes);
                quotes = temp;
            }
            if (LastName != String.Empty && LastName != null)
            {
                temp = ByLastNameSearch(LastName, quotes);
                quotes = temp;
            }
            if (DateEnd != String.Empty && DateStart != String.Empty && DateEnd != null && DateStart != null)
            {
                temp = ByDateSearch(DateStart,DateEnd, quotes);
                quotes = temp;
            }
            /*if (zip != String.Empty)
            {
                quotes = ByZipSearch(Id, quotes);
            }*/
            if (state != String.Empty && state != null)
            {
                temp = ByStateSearch(state, quotes);
                quotes = temp;
            }
            if (submitted != String.Empty && submitted != null)
            {
                temp = BySubmittedSearch(Boolean.Parse(submitted), quotes);
                quotes = temp;
            }
            if (phone != String.Empty && phone != null)
            {
                temp = ByPhoneSearch(phone, quotes);
                quotes = temp;
            }

            return Ok(quotes.ToList());
        }

        private IQueryable<Quote> BySubmittedSearch(bool query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.Submitted == query);
        }

        private IQueryable<Quote> ByIdSearch(string query, IQueryable<Quote> quotes)
        {
            return quotes.Where(x => x.Id.ToString().Equals(query));
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuoteExists(long id)
        {
            return db.Quotes.Count(e => e.Id == id) > 0;
        }
    }
}
