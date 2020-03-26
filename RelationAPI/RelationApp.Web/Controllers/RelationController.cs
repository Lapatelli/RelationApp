using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Core.Entities;
using RelationApp.Core.Interfaces.Services;
using RelationApp.Web.ViewModels;

namespace RelationApp.Web.Controllers
{
    [Route("relations/")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRelationService _relationService;

        public RelationController(IMapper mapper, IRelationService relationService)
        {
            _mapper = mapper;
            _relationService = relationService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetAllCategoryRelationsAsync([FromQuery] Guid? categoryId)
        {
            var relations = categoryId != null ? await _relationService.GetRelationsByCategotyIdAsync(categoryId) : await _relationService.GetAllRelationsAsync();

            var resultRelation = _mapper.Map<IEnumerable<Relation>, IEnumerable<GetAllRelationsViewModel>>(relations);

            return Ok(resultRelation);
        }

        [HttpGet, Route("SortBy{sortedProp}")]
        public async Task<IActionResult> GetSortedAllCategoryRelationsAsync([FromQuery] Guid? categoryId,string sortedProp, bool ascending)
        {
            var sortedRelations = await _relationService.GetSortedRelationsByCategotyIdAsync(categoryId, sortedProp, ascending);

            var resultSortedRelations = _mapper.Map<IEnumerable<Relation>, IEnumerable<GetAllRelationsViewModel>>(sortedRelations);

            return Ok(resultSortedRelations);
        }
    }
}