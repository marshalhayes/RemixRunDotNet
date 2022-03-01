import { LoaderFunction, useLoaderData } from 'remix';

export const loader: LoaderFunction = async () => {
  const res = await fetch(`${process.env.BACKEND_URL}/api/hello`, {
    headers: {
      Accept: 'application/json',
    },
  });

  return await res.json();
};

export default function Index() {
  const data = useLoaderData();

  return (
    <>
      <h1>{data}</h1>
    </>
  );
}
