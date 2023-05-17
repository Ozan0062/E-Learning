using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

public class RegisterPageModel : CreatePageModel<User>
{

	public RegisterPageModel(IUserDataService userDataService)
        : base(userDataService, "/Index")
	{
	}


	public override IActionResult OnPost()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		// Submit data to data service
		_dataService.Create(Data);

		return RedirectToPage("/LogIn/LogInPage");
		}
	}


