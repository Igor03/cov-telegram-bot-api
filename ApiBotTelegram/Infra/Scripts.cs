using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Infra
{
    public class Scripts
    {
        internal readonly static string SELECT_AVAILABLE_COUNTRIES = @" select 
	                                                                        id,
	                                                                        country_name countryName,
	                                                                        country_name_search countryNameSearch,
	                                                                        region, subregion, population,
	                                                                        last_search lastSearch
                                                                         from country";

        internal readonly static string SELECT_COUNTRY_BY_NAME = @" select* from country
                                                                    where country_name = @CountryName";

        internal readonly static string SELECT_COUNTRIES_SITUATION = @"select 
	                                                                    cs.id  id,
	                                                                    cs.country_id countryId,
	                                                                    cs.active_cases activeCases,
	                                                                    cs.recovered_cases recoveredCases,
	                                                                    cs.fatal_cases fatalCases,
	                                                                    cs.search_date searchDate,
	                                                                    co.id,
	                                                                    co.country_name countryName,
	                                                                    co.country_name_search countryNameSearch,
	                                                                    co.region, co.subregion, co.population,
	                                                                    co.last_search lastSearch
	                                                                    from country co
                                                                    inner join country_situation cs on cs.country_id = co.id
                                                                    where convert(date, co.last_search) = convert(date, cs.search_date)";

        public static string GetCountrySituationQuery(string CountryName)
        {
                return $@"select 
	                    cs.id  id,
	                    cs.country_id countryId,
	                    cs.active_cases activeCases,
	                    cs.recovered_cases recoveredCases,
	                    cs.fatal_cases fatalCases,
	                    cs.search_date searchDate,
	                    co.id,
	                    co.country_name countryName,
	                    co.country_name_search countryNameSearch,
	                    co.region, co.subregion, co.population, 
	                    co.last_search lastSearch
	                    from country co
                    inner join country_situation cs on cs.country_id = co.id
                    where convert(date, co.last_search) = convert(date, cs.search_date) and co.country_name = '{CountryName}'";
        }

        internal readonly static string GET_COUNTRY_SITUATION = @"select 
	                                                                    cs.id  id,
	                                                                    cs.country_id countryId,
	                                                                    cs.active_cases activeCases,
	                                                                    cs.recovered_cases recoveredCases,
	                                                                    cs.fatal_cases fatalCases,
	                                                                    cs.search_date searchDate,
	                                                                    co.id,
	                                                                    co.country_name countryName,
	                                                                    co.country_name_search countryNameSearch,
	                                                                    co.region, co.subregion, co.population, 
	                                                                    co.last_search lastSearch
	                                                                    from country co
                                                                    inner join country_situation cs on cs.country_id = co.id
                                                                    where convert(date, co.last_search) = convert(date, cs.search_date) and co.country_name = @CountryName";
    }
}