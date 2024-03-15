/* 3rd party libraries */
import { ComponentFixture, TestBed } from '@angular/core/testing';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import { #PascalName#Page } from './#dash-name#.page';

describe('#PascalName#Page', () => {
  let component: #PascalName#Page;
  let fixture: ComponentFixture<#PascalName#Page>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [#PascalName#Page]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(#PascalName#Page);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
