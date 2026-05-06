import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDetail } from './add-detail';

describe('AddDetail', () => {
  let component: AddDetail;
  let fixture: ComponentFixture<AddDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddDetail],
    }).compileComponents();

    fixture = TestBed.createComponent(AddDetail);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
