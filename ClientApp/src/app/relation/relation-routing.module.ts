import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModalContainerComponent } from './modal-containter.component';
import { RelationListComponent } from './relation-list/relation-list.component';


const routes: Routes = [
  { path: '', component: RelationListComponent,
    children: [
      { path: 'create', component: ModalContainerComponent },
      { path: 'update', component: ModalContainerComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RelationRoutingModule { }
