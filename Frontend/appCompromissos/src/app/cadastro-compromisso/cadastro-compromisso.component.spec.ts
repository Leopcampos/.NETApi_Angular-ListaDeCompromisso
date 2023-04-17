import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroCompromissoComponent } from './cadastro-compromisso.component';

describe('CadastroCompromissoComponent', () => {
  let component: CadastroCompromissoComponent;
  let fixture: ComponentFixture<CadastroCompromissoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroCompromissoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroCompromissoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
