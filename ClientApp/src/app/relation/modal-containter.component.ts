import { Component, OnDestroy } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { CreateUpdateRelationComponent } from './create-update-relation/create-update-relation.component';

@Component({
  selector: 'app-modal-container',
  template: ''
})
export class ModalContainerComponent implements OnDestroy {
  destroy = new Subject<any>();
  currentDialog = null;

  constructor(private modalService: NgbModal, route: ActivatedRoute, router: Router) {
    route.paramMap.pipe(takeUntil(this.destroy)).subscribe(params => {
      this.currentDialog = this.modalService.open(CreateUpdateRelationComponent, {centered: true});

      this.currentDialog.result.then(result => {
        router.navigateByUrl('/');
      },
      reason => {
        router.navigateByUrl('/');
      });
    });
  }

  ngOnDestroy() {
    this.currentDialog.close();
  }
}
