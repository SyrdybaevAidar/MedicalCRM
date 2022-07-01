using MedicalCRM.DataAccess.Contexts;
using MedicalCRM.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Repositories.UserRepositories {
    public class UserRepository<T> : Repository<T> where T: User {
        public UserRepository(ApplicationDbContext context) : base(context) {
        }

        public virtual IQueryable<T> GetFilteredUsersQuery(UserFilterView filter) {
            var query = All
                .Where(i => i.UserName.Contains(filter.UserName ?? ""))
                .Where(i => i.Name.Contains(filter.Name ?? ""))
                .Where(i => i.Surname.Contains(filter.Surname ?? ""))
                .Where(i => i.Patronimic.Contains(filter.Patronimic ?? ""))
                .Where(i => filter.BirthDateEnd == null || i.BirthDate < filter.BirthDateEnd)
                .Where(i => filter.BirthDateStart == null || i.BirthDate > filter.BirthDateStart);

            return query;
        }
    }
}
