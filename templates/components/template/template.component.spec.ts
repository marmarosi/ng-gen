/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalName##PascalType# } from './#dash-name#.#dash-type#';

describe('#PascalName##PascalType#', () => {
  let #camelType#: #PascalName##PascalType#;
  let fixture: #PascalType#Fixture<#PascalName##PascalType#>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [#PascalName##PascalType#]
    })
    .compileComponents();
    
    fixture = TestBed.create#PascalType#(#PascalName##PascalType#);
    #camelType# = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(#camelType#).toBeTruthy();
  });
});
