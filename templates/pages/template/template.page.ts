/* 3rd party libraries */
import { ChangeDetectionStrategy, Component } from '@angular/core';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

@Component({
  templateUrl: './#dash-name#.page.html',
  styleUrl: './#dash-name#.page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class #PascalName#Page {

}
