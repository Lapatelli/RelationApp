import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { RelationRoutingModule } from './relation-routing.module';
import { RelationListComponent } from './relation-list/relation-list.component';
import { CreateRelationComponent } from './create-relation/create-relation.component';
import { RelationService } from './services/relation.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalContainerComponent } from './modal-containter.component';


@NgModule({
  declarations: [
    RelationListComponent,
    CreateRelationComponent,
    ModalContainerComponent,
  ],
  imports: [
    CommonModule,
    RelationRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [
    RelationService
  ],
  bootstrap: [
    RelationListComponent
  ]
})
export class RelationModule { }
