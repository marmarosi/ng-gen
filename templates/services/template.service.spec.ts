/* 3rd party libraries */
import { TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalSingle##PascalType# } from './#dash-single#.#dash-type#';

describe('#PascalSingle##PascalType#', () => {
  let #camelType#: #PascalSingle##PascalType#;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    #camelType# = TestBed.inject(#PascalSingle##PascalType#);
  });

  it('should be created', () => {
    expect(#camelType#).toBeTruthy();
  });
});