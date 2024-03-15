/* 3rd party libraries */
import { ChangeDetectionStrategy, Component } from '@angular/core';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

@Component({
  selector: '#prefix#-#dash-name#',
  templateUrl: './#dash-name#.#dash-type#.html',
  styleUrl: './#dash-name#.#dash-type#.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class #PascalName##PascalType# {

}
