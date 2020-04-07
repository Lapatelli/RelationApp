import { Component, OnInit, OnDestroy } from '@angular/core';
import { RelationService } from '../services/relation.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Relation } from 'src/app/shared/relation';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-create-update-relation',
  templateUrl: './create-update-relation.component.html',
  styleUrls: ['./create-update-relation.component.scss']
})
export class CreateUpdateRelationComponent implements OnInit, OnDestroy {

  public createModel = true;
  public actionName = 'Create';
  public relationFormModel: any;
  public relationJSON: any;
  public relationId: string = null;
  public relation: Relation;
  destroy = new Subject<any>();

  constructor(private router: Router, private service: RelationService, private fb: FormBuilder, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.InitializeRelationModel();
    this.CreateFormModel();
  }

  InitializeRelationModel(): void {
    this.route.queryParams.subscribe(params => {
      this.relationId = params.id;
      this.relationJSON = params.relation;
    });

    if (this.relationId !== undefined) {
      this.relation = JSON.parse(this.relationJSON);
      this.createModel = false;
      this.actionName = 'Update';
    }
    else {
      this.relation = {
        id: '',
        name: '',
        fullName: '',
        telephoneNumber: '',
        emailAddress: '',
        countryName: '',
        city: '',
        postalCode: '',
        street: '',
        streetNumber: null
        };
    }
  }

  CreateFormModel(): void{
    this.relationFormModel = this.fb.group({
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

  onDetermineAction(): void {
    if (this.createModel) {
      this.onCreate();
    }
    else {
      this.onEdit();
    }
  }

  onCreate(): void {
    this.service.createRelation(this.relationFormModel.value)
      .subscribe((res: any) => {
        this.router.navigateByUrl('/');
      });

    this.relationFormModel.reset();
    this.ngOnDestroy();
  }

  onEdit(): void {
    this.service.editRelation(this.relation.id, this.relationFormModel.value)
    .subscribe((res: any) => {
      this.router.navigate(['/']);
    });

    this.ngOnDestroy();
  }

  onClose(): void {
    this.router.navigateByUrl('/');
    this.ngOnDestroy();
  }

  ngOnDestroy() {
    this.destroy.next();
  }
}
