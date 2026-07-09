import type { Route } from "./+types/home";
import { Welcome } from "../welcome/welcome";
import { PollForm } from "./pollform";

export function meta({}: Route.MetaArgs) {
  return [
    { title: "New React Router App" },
    { name: "description", content: "Welcome to React Router!" },
  ];
}

export default function Home() {
    return (
        <>
            <main className="justify-items-center pt-8 pb-4">
            <Welcome/>
            <PollForm />
            </main>
        </>
    );
}
