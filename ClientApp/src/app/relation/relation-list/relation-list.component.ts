import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { RelationService } from '../services/relation.service';
import { Relation } from 'src/app/shared/relation';
import { categories } from 'src/app/shared/categories';
import { DeleteRelation } from 'src/app/shared/relation-delete';
import { FormBuilder} from '@angular/forms';
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

  public category: string = null;
  public sortedProperty: string = 'Name';
  public descending: boolean = false;
  public sortedObject: SortedObject;
  public categoriesArray: Array<Category>;
  public selectedCategory: Category = new Category();

  constructor(private router: Router, private service: RelationService, private fb: FormBuilder) { }

  ngOnInit(): void {

    this.categoriesArray = new Array(
      {name: 'Category_1', value: categories.Category_1},
      {name: 'Category_2', value: categories.Category_2},
      {name: 'Category_3', value: categories.Category_3},
      {name: 'Category_4', value: categories.Category_4},
      {name: 'Category_5', value: categories.Category_5},
      {name: 'Category_6', value: categories.Category_6},
      {name: 'Category_7', value: categories.Category_7},
      {name: 'Category_8', value: categories.Category_8},
      {name: 'All categories', value: null}
    );

    this.sortedObject = {
      property: this.sortedProperty,
      desc: this.descending
    };

    this.relations$ = this.service.getRelations(this.category, this.sortedProperty, this.descending);
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
    const relationExtras: NavigationExtras = {
      queryParams: {
        // tslint:disable-next-line: quotemark
        // tslint:disable-next-line: object-literal-key-quotes
        'relationToUpdate': JSON.stringify(relation)
      }
    };
    this.router.navigate(['/update'], relationExtras);
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
    console.log(this.relationCheckingOptions);
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
        console.log('ok');
        this.relations$ = this.service.getRelations(this.category, this.sortedProperty, this.descending);
    },
    err =>
      console.log(err)
    );
  }

}
