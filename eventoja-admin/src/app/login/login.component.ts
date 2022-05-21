import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  usuario: string = '';
  senha: string = '';
  constructor(private usuarioService: UsuarioService,private router: Router) {}

  ngOnInit(): void {}

  async logar() {
    console.log('USUARIO', this.usuario);
    console.log('SENHA', this.senha);
    const usuarioApi = await this.usuarioService.login(
      this.usuario,
      this.senha
    );
    if (usuarioApi == null) {
      alert("Usuário não encontrado!")
    }else{
      this.router.navigate(['/painel']);
    }
  }
}
