// custom hooks separate the fetching logic from ui components
import config from "../config";
import axios from "axios";
import { useQuery } from "react-query";

function useFetchProfile() {
   return useQuery("profile", () => 
        axios.get(`${config.baseApiUrl}/profile`).then((resp) => resp.data)
   );
}

export { useFetchProfile };