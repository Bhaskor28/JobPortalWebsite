﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.Categories
{
    public interface ICategoryService
    {
        Task<IList<CategoryVM>> GetAllCategoryAsync();
    }
}
