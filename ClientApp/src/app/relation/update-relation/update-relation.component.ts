import { Component, OnInit, Input } from '@angular/core';
import { RelationService } from '../services/relation.service';
import { FormBuilder } from '@angular/forms';
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
      Name: [this.relation.name],
      FullName: [this.relation.fullName],
      TelephoneNumber: [this.relation.telephoneNumber],
      EmailAddress: [this.relation.emailAddress],
      Country: [this.relation.countryName],
      City: [this.relation.city],
      PostalCode: [this.relation.postalCode],
      Street: [this.relation.street],
      StreetNumber: [this.relation.streetNumber],
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
