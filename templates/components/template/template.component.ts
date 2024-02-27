/* 3rd party libraries */
import { ChangeDetectionStrategy, Component } from '@angular/core';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

@Component({
  selector: '#prefix#-#dash-single#',
  templateUrl: './#dash-single#.#dash-type#.html',
  styleUrl: './#dash-single#.#dash-type#.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class #PascalSingle##PascalType# {

}