using ClubFund.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using ClubFund.Services;

namespace ClubFund.Controllers
{
	

	public class MemberController : Controller
	{

		private readonly MemberService _memberService;

		public MemberController(MemberService memberService)
		{
			_memberService = memberService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var dbMember = await _memberService.GetAllMembers();
			var vmList = new List<MemberListVM>();

			foreach (var member in dbMember)
			{
				var vm = new MemberListVM
				{
					Id = member.Id,
					FirstName = member.FirstName,
					LastName = member.LastName,
					Image = member.Image,
					IsActive = member.IsActive
				};

				vmList.Add(vm);
			}

			return View(vmList);
		}
		


		[HttpGet]
		public IActionResult CreateMember()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateMember(CreateMemberVM vm, IFormFile Image)
		{

			await _memberService.CreateMember(vm, Image);

			


			return View();
		}
	}
}
