/* 3rd party libraries */
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */

@Injectable( {
  providedIn: 'root'
} )
export class #PascalSingle#Navigator {

  #root = '/#dash-single#';

  constructor(
    protected readonly router: Router
  ) { }

  // list(): void {
  //   this.router.navigate( [ this.#root ] );
  // }
  //
  // view(
  //   key: number
  // ): void {
  //   this.router.navigate( [ this.#root, key ] );
  // }
  //
  // edit(
  //   key: number
  // ): void {
  //   this.router.navigate( [ this.#root, key, 'edit' ] );
  // }
}