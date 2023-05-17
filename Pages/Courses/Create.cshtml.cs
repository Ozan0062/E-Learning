using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace E_Learning.Pages.Courses
{
	public class CreateModel : CreatePageModel<Course>
	{ 

		public CreateModel(ICourseDataService dataService, IEducationDataService educationDataService)
			: base(dataService)
		{
			EducationList = new SelectList(educationDataService.GetAll(), nameof(Education.Id), nameof(Education.Name));
		}

		public SelectList EducationList { get; set; }


	}

}
