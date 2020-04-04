import { Component, OnInit } from '@angular/core';
import { RelationService } from '../services/relation.service';
import { FormBuilder, Validators } from '@angular/forms';
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
      Name: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      FullName: ['', [Validators.minLength(2), Validators.maxLength(100)]],
      TelephoneNumber: ['', [Validators.minLength(2), Validators.maxLength(15)]],
      EmailAddress: ['', [Validators.email, Validators.maxLength(50)]],
      Country: ['', [Validators.minLength(2), Validators.maxLength(60)]],
      City: ['', [Validators.minLength(2), Validators.maxLength(100)]],
      PostalCode: ['', [Validators.minLength(2), Validators.maxLength(20)]],
      Street: ['', [Validators.minLength(2), Validators.maxLength(100)]],
      StreetNumber: ['', [Validators.minLength(2)]],
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
