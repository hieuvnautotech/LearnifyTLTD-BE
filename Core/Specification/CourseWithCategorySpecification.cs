using Entity;

namespace Core.Specifications
{
    public class CourseWithCategorySpecification : BaseSpecification<Course>
    {
        public CourseWithCategorySpecification(string search, int? categoryId, string sort, int skip, int take)
            : base(x =>
                (string.IsNullOrEmpty(search) || x.Title.ToLower().Contains(search)) &&
                (!categoryId.HasValue || x.CategoryId == categoryId))
        {
            AddInclude(x => x.Category);
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Title);
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.Title);
            }
        }
    }
}
