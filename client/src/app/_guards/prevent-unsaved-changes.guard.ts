import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';
import { ComfirmService } from '../_services/comfirm.service';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {

  /**
   *
   */
  constructor(private confirmService: ComfirmService) {
  }

  canDeactivate(
    component: MemberEditComponent):Observable<boolean> | boolean {
      if(component.editForm.dirty){
        return this.confirmService.confirm()
      }
      return true;
  }

}
