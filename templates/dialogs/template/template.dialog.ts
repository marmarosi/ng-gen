/* 3rd party libraries */
import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalName#Data } from '../../models';

@Component({
  templateUrl: './#dash-name#.dialog.html',
  styleUrl: './#dash-name#.dialog.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class #PascalName#Dialog {

  constructor(
    @Inject( MAT_DIALOG_DATA ) public readonly data: Observable<#PascalName#Data>
  ) { }
}
