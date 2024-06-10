import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SideListFeatureComponent } from './side-list-feature.component';

describe('SideListFeatureComponent', () => {
  let component: SideListFeatureComponent;
  let fixture: ComponentFixture<SideListFeatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SideListFeatureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SideListFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
