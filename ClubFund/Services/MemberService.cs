using ClubFund.Data;
using ClubFund.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClubFund.Services
{
	public class MemberService
	{
		private readonly ClubFundContext _ctx;
		public MemberService(ClubFundContext ctx)
		{
			_ctx = ctx;
		}

		internal async Task<bool> CreateMember(CreateMemberVM vm, IFormFile Image)
		{
			if (Image != null && Image.Length > 0)
			{
				using var ms = new MemoryStream();
				
				var image = SixLabors.ImageSharp.Image.Load(Image.OpenReadStream());
				image.Mutate(x => x.Resize(new ResizeOptions { Size = new Size(500, 0), Mode = ResizeMode.Max }));
				image.Save(ms, new JpegEncoder());

				
				vm.Image = ms.ToArray();
			}

			Member member = new Member
			{
				FirstName = vm.FirstName,
				LastName = vm.LastName,
				IsActive = true,
				Image = vm.Image

			};

			_ctx.Members.Add(member);
			await _ctx.SaveChangesAsync();


			return true;
		}

		internal async Task<List<Member>> GetAllMembers()
		{
			return await _ctx.Members
				.ToListAsync();

		}
	}
}
