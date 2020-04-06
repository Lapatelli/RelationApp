import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RelationRoutingModule } from './relation-routing.module';
import { RelationListComponent } from './relation-list/relation-list.component';
import { CreateRelationComponent } from './create-relation/create-relation.component';
import { UpdateRelationComponent } from './update-relation/update-relation.component';
import { RelationService } from './services/relation.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    RelationListComponent,
    CreateRelationComponent,
    UpdateRelationComponent
  ],
  imports: [
    CommonModule,
    RelationRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    RelationService
  ]
})
export class RelationModule { }
