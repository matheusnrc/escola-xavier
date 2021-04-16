import styled, { createGlobalStyle } from "styled-components";

export const GlobalStyle = createGlobalStyle`
* {
  box-sizing: border-box;
  font-family: "Montserrat", sans-serif;
  margin: 0;
  padding: 0;
  text-decoration: none;
}
`;

export const Box = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  background-color: #4a4a4a;
  border-radius: 5px;
  box-shadow: 4px 4px 20px 0px rgba(0, 0, 0, 0.04);
  padding: 20px;
  width: 50%;

  margin-top: 50px;

  @media (max-width: 800px) {
    width: 95%;
    margin: 5px;
  }
`;

export const Input = styled.input`
  margin-top: 8px;
  padding: 4px;
  border-radius: 20px;
  background-color: black;
  font-weight: 100;
  color: white;

  border: 2px solid white;
  box-shadow: 0 0 0 0;
  outline: 0;
`;

export const Botao = styled.button`
  text-align: center;
  border-radius: 20px;
  padding: 5px 20px;
  margin: 10px 0px;
  font-weight: 600;
  border: 2px solid white;
  cursor: pointer;
  background: black;
  color: white;
  box-shadow: 0 0 0 0;
  outline: 0;
`;

export const Select = styled.select`
    text-align: center;
    border-radius: 20px;
    padding: 5px 20px;
    margin: 10px 0px;
    font-weight: 600;
    border: 2px solid white;
    cursor: pointer;
    background: black;
    color: white;
    box-shadow: 0 0 0 0;
    outline: 0;
  `;

export const Titulo = styled.h2`
  color: white;
  text-align: center;
`;

export const Formulario = styled.form`
  display: flex;
  flex-direction: column;
`;
