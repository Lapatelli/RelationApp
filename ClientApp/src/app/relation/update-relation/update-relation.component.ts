import { Component, OnInit, Input } from '@angular/core';
import { RelationService } from '../services/relation.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RelationModule } from '../relation.module';
import { Relation } from 'src/app/shared/relation';

@Component({
  selector: 'app-update-relation',
  templateUrl: './update-relation.component.html',
  styleUrls: ['./update-relation.component.scss']
})
export class UpdateRelationComponent implements OnInit {

  public relationJSOn: any;
  public updateRelationFormModel: any;
  public relation: Relation;

  constructor(private router: Router, private service: RelationService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.route.queryParams.subscribe(params => {
      this.relationJSOn = params['relationToUpdate'];
    });

    this.relation = JSON.parse(this.relationJSOn);
    console.log(this.relation.id);
  }

  ngOnInit(): void {
    this.updateRelationFormModel = this.fb.group({
      Name: [this.relation.name, [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      FullName: [this.relation.fullName, [Validators.minLength(2), Validators.maxLength(100)]],
      TelephoneNumber: [this.relation.telephoneNumber, [Validators.minLength(2), Validators.maxLength(15)]],
      EmailAddress: [this.relation.emailAddress, [Validators.email, Validators.maxLength(50)]],
      Country: [this.relation.countryName, [Validators.minLength(2), Validators.maxLength(60)]],
      City: [this.relation.city, [Validators.minLength(2), Validators.maxLength(100)]],
      PostalCode: [this.relation.postalCode, [Validators.minLength(2), Validators.maxLength(20)]],
      Street: [this.relation.street, [Validators.minLength(2), Validators.maxLength(100)]],
      StreetNumber: [this.relation.streetNumber, [Validators.minLength(2)]],
    });
  }

  onEdit(): void {
    this.service.editRelation(this.relation.id, this.updateRelationFormModel.value)
    .subscribe((res: any) => {
        console.log('ok');
        this.router.navigate(['']);
    },
    err =>
      console.log(err)
    );
  }
}
