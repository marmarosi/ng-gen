/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalName#Dialog } from './#dash-name#.dialog';

describe('#PascalName#Dialog', () => {
  let component: #PascalName#Dialog;
  let fixture: ComponentFixture<#PascalName#Dialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ #PascalName#Dialog ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(#PascalName#Dialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
