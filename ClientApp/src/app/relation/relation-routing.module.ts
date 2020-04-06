import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RelationListComponent } from './relation-list/relation-list.component';
import { CreateRelationComponent } from './create-relation/create-relation.component';
import { UpdateRelationComponent } from './update-relation/update-relation.component';


const routes: Routes = [
  { path: '', component: RelationListComponent },
  { path: 'create', component: CreateRelationComponent },
  { path: 'update', component: UpdateRelationComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelationRoutingModule { }
