import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, NavigationExtras, ActivatedRoute, NavigationEnd } from '@angular/router';
import { RelationService } from '../services/relation.service';
import { Relation } from 'src/app/shared/relation';
import { categories } from 'src/app/shared/categories';
import { DeleteRelation } from 'src/app/shared/relation-delete';
import { CheckBoxRelation } from 'src/app/shared/check-box-relation';
import { SortedObject } from 'src/app/shared/sorted-object';
import { Category } from 'src/app/shared/category';

@Component({
  selector: 'app-relation-list',
  templateUrl: './relation-list.component.html',
  styleUrls: ['./relation-list.component.scss']
})
export class RelationListComponent implements OnInit {

  public relations$: Observable<Relation[]>;
  public relation: Relation;
  public relationsToDelete: DeleteRelation[] = [];
  public relationCheckingOptions = new Array<CheckBoxRelation>();
  public checkBoxRelation: CheckBoxRelation;
  public deleteButtonShow: boolean = false;

  public category: string = null;
  public sortedProperty: string = 'Name';
  public descending: boolean = false;
  public sortedObject: SortedObject;
  public categoriesArray: Array<Category>;
  public selectedCategory: Category = new Category();

  constructor(private router: Router, private service: RelationService, private route: ActivatedRoute) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.relations$ = this.service.getRelations(this.category, this.sortedProperty, this.descending);
      }
    });
   }

  ngOnInit(): void {

    this.categoriesArray = new Array(
      {name: 'Chauffeurs', value: categories.Chauffeurs},
      {name: 'Opdrachtgevers', value: categories.Opdrachtgevers},
      {name: 'Transporteurs', value: categories.Transporteurs},
      {name: 'Crediteuren', value: categories.Crediteuren},
      {name: 'Depots', value: categories.Depots},
      {name: 'Gearchiveerde Relaties', value: categories.Gearchiveerde_Relaties},
      {name: 'Laadadressen', value: categories.Laadadressen},
      {name: 'Losadressen', value: categories.Losadressen},
      {name: 'All categories', value: null}
    );

    this.selectedCategory = this.categoriesArray.find(x => x.name === 'All categories');

    this.sortedObject = {
      property: this.sortedProperty,
      desc: this.descending
    };
  }

  onSelectCategory(category: string): void {
    this.category = category;
    this.selectedCategory = this.categoriesArray.find(x => x.value === this.category);

    this.relations$ = this.service.getRelations(this.category, this.sortedProperty, this.descending);
  }

  onSort(sortedProperty: any): void {
    if (this.sortedObject.property === sortedProperty) {
      this.sortedObject.desc = this.sortedObject.desc ? false : true;
    }
    else {
      this.sortedObject.property = sortedProperty;
      this.sortedObject.desc = false;
    }
    this.relations$ = this.service.getRelations(this.category, this.sortedObject.property, this.sortedObject.desc);
  }

  onNavigateToUpdate(relation: Relation): void {
    this.router.navigate(['update/' + relation.id]);
  }

  onToggle(relationId: string): void {
    if (this.relationCheckingOptions.find(x => x.id === relationId)) {
      const relationToToggle = this.relationCheckingOptions.find(x => x.id === relationId);
      relationToToggle.checked = relationToToggle.checked ? false : true;
    }
    else {
      this.relationCheckingOptions.push(this.checkBoxRelation = {
        id: relationId,
        checked: true
      });
    }

    if (this.relationCheckingOptions.find(x => x.checked === true)) {
      this.deleteButtonShow = true;
    }
    else {
      this.deleteButtonShow = false;
    }
  }

  onDelete(): void {
    this.relationCheckingOptions.forEach(cr => {
      if (cr.checked) {
        const item: DeleteRelation = {
          id: cr.id
        };
        this.relationsToDelete.push(item);
      }
    });

    this.service.deleteRelations(this.relationsToDelete)
      .subscribe((res: any) => {
        this.relations$ = this.service.getRelations(this.category, this.sortedProperty, this.descending);
    });
  }
}
