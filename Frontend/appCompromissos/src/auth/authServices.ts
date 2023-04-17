const ACCESS_TOKEN = "access_token";

//função para gravar o token em sessão
export const addAccessToken = (token: any) => {
    window.localStorage.setItem(ACCESS_TOKEN, token);
};

//função para retornar o token gravado
export const getAccessToken = () => {
    return window.localStorage.getItem(ACCESS_TOKEN);
}

//função para destruir o token gravado em sessão
export const removeAccessToken = () => {
    window.localStorage.removeItem(ACCESS_TOKEN);
}

//função para redirecionar para a área restrita
export const redirectToAdminPage = () => {
    window.location.href = "/admin";
}

//função para redirecionar de volta para a página de login
export const redirectToLoginPage = () => {
    window.location.href = "/login";
}