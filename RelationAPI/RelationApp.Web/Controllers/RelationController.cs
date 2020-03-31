﻿using System;
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
        private readonly Random _random;

        public RelationController(IMapper mapper, IRelationService relationService)
        {
            _mapper = mapper;
            _relationService = relationService;

            _random = new Random();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetSortedAllCategoryRelationsAsync([FromQuery] Guid? categoryId, string propertyForSorting, bool descending)
        {
            var relationsSorted = await _relationService.GetSortedRelationsByCategotyIdAsync(categoryId, propertyForSorting, descending);

            var relationsSortedViewModel = _mapper.Map<IEnumerable<Relation>, IEnumerable<GetRelationViewModel>>(relationsSorted);

            return Ok(relationsSortedViewModel);
        }

        /// <summary>
        /// RandomCategoryId is added for Unit-Tests. After creating UI, there will be Dropdown menu to choose right category
        /// </summary>
        /// <param name="createRelationViewModel"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateRelation([FromBody]CreateRelationViewModel createRelationViewModel)
        {
            var randomCategoryLastNumber = _random.Next(1, 8).ToString();
            var randomCategoryId = Guid.Parse($"00000000-0000-0000-0000-00000000000{randomCategoryLastNumber}");

            var relation = _mapper.Map<CreateRelationViewModel, Relation>(createRelationViewModel);
            var relationAddress = _mapper.Map<(CreateRelationViewModel,Relation), RelationAddress>((createRelationViewModel, relation));
            var relationCategory = _mapper.Map<(Relation,Guid), RelationCategory>((relation, randomCategoryId));

            var relationCreated = await _relationService.CreateRelationAsync(relation, relationAddress, relationCategory);

            var relationCreatedViewModel = _mapper.Map<Relation, GetRelationViewModel>(relationCreated);

            return Ok(relationCreatedViewModel);
        }

        [HttpPut("update/{relationId}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateRelation([FromRoute] Guid relationId,[FromBody] UpdateRelationViewModel updateRelationViewModel)
        {
            var relation = _mapper.Map<(UpdateRelationViewModel, Guid), Relation>((updateRelationViewModel, relationId));
            var relationAddress = _mapper.Map<(UpdateRelationViewModel, Guid), RelationAddress>((updateRelationViewModel, relationId));

            var relationUpdated = await _relationService.UpdateRelationById(relation, relationAddress);

            var relationUpdatedViewModel = _mapper.Map<Relation, GetRelationViewModel>(relationUpdated);

            return Ok(relationUpdatedViewModel);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteRelation([FromBody]IEnumerable<DeleteRelationViewModel> deleteRelationViewModel)
        {
            var relationsToDelete = _mapper.Map<IEnumerable<DeleteRelationViewModel>, IEnumerable<Relation>>(deleteRelationViewModel);

            await _relationService.DeleteCertainRelationsByMakingDisabled(relationsToDelete);

            return NoContent();
        }
    }
}