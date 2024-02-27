/* 3rd party libraries */
import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalSingle#Data } from '../../models';

@Component({
  templateUrl: './#dash-single#.dialog.html',
  styleUrl: './#dash-single#.dialog.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class #PascalSingle#Dialog {

  constructor(
    @Inject( MAT_DIALOG_DATA ) public readonly data: Observable<#PascalSingle#Data>
  ) { }
}