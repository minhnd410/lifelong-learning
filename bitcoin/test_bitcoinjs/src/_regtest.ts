import { RegtestUtils } from 'regtest-client';

const APIPASS = process.env.APIPASS || 'polarpass';
// const APIURL = process.env.APIURL || 'http://localhost:45123/1';
const APIURL = process.env.APIURL || 'http://127.0.0.1:18446';

export const regtestUtils = new RegtestUtils({ APIURL, APIPASS });