import { Component, OnInit } from '@angular/core';
import { RelationService } from '../services/relation.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-relation',
  templateUrl: './create-relation.component.html',
  styleUrls: ['./create-relation.component.scss']
})
export class CreateRelationComponent implements OnInit {

  public newRelationFormModel: any;

  constructor(private router: Router, private service: RelationService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.newRelationFormModel = this.fb.group({
      Name: [''],
      FullName: [''],
      TelephoneNumber: [''],
      EmailAddress: [''],
      Country: [''],
      City: [''],
      PostalCode: [''],
      Street: [''],
      StreetNumber: [''],
    });

    this.newRelationFormModel.reset();
  }

  onCreate(): void {
    console.log(this.newRelationFormModel.value);
    this.service.createRelation(this.newRelationFormModel.value)
      .subscribe((res: any) => {
        this.router.navigate(['']);
      },
      err =>
        console.log(err)
      );
    this.newRelationFormModel.reset();
  }
}
