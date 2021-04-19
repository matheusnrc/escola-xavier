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

//Atualização do Web

export const Container = styled.div`
  padding-right: 1rem;
  padding-left: 1rem;

  @media (min-width: 800px) {
    padding-right: 2.5rem;
    padding-left: 2.5rem;
  }

  @media (min-width: 1200px) {
    padding-left: calc((100vw - 900px) / 2);
    padding-right: calc((100vw - 900px) / 2);
  }
`;




